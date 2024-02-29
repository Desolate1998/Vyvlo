import { Button, Card, Dropdown, Field, Input, Text, Option, Textarea, Toaster } from '@fluentui/react-components';
import React, { ChangeEvent, useState } from 'react';
import ReactCountryFlag from 'react-country-flag';
import { flags } from './FirsStoreController';
import ImagePreview from '../../Components/ImagePreviewer/ImagePreviewer';
import './FirstStoreCreation.css'; // Import CSS file for custom styling
import { storeApi } from '../../Infrastructure/API/Requests/Store/storeApi';
import { useToaster } from '../../Infrastructure/Contexts/ToasterContext';

export const FirstStoreCreation = () => {
  const [image, setImage] = useState<File | undefined>();
  const [location, setLocation] = useState<string>('')
  const [currency, setCurrency] = useState<string>('')
  const [description, setDescription] = useState<string>('')
  const [storeName, setStoreName] = useState<string>('')
  const [loading, setLoading] = useState(false)
  const { notify, mainToast } = useToaster();

  const handleSubmit = async () => {
    let formData = new FormData();
    formData.append('name', storeName);
    formData.append('description', description);
    formData.append('currency', currency);
    formData.append('location', location);
    formData.append('storeImage', image!);

    try {
      setLoading(true)
      let response =await storeApi.create(formData);
      if (response.isError) {
        notify(response.firstError.description, 'error')
      } else {
        notify('Store created successfully', 'success')
      }
    } catch (error) {
      notify('An error occured', 'error')
    }finally{
      setLoading(false)
    }
  }


  const handleImageChange = async (e: ChangeEvent<HTMLInputElement>) => {
    await new Promise(resolve => setTimeout(resolve, 100));
    if (e.target.files) {
      setImage(e.target.files[0]);
    }
  };

  return (
    <div className='store-creation-body'>
      <Toaster
        toasterId={mainToast}
        position="top-end"
        pauseOnHover
        pauseOnWindowBlur
        timeout={1000}
      />
    <Card className="store-creation-card">
      <Text  className="welcome-text">Welcome to the start of something amazing</Text>
      <Text  className="start-text">Let's get started by creating your first store</Text>

      <Field label='Store Name'>
        <Input className="input-field" value={storeName} onChange={(e) => setStoreName(e.target.value)} />
      </Field>
      <Field hint='Tell us something about your store'  label='Description'>
      <Textarea value={description} onChange={(e) => setDescription(e.target.value)} />
      </Field>
      <Field label='Currency'>
        <Dropdown className="dropdown"  onOptionSelect={(_,d)=>  setCurrency(d.selectedOptions[0])}>
          <Option value='1'>(R) ZAR</Option>
          <Option value='2'>($) USD</Option>
          <Option value='3'>(£) POND</Option>
        </Dropdown>
      </Field>

      <Field label='Where is the store located'>
        <Dropdown className="dropdown" onOptionSelect={(_,d)=>  setLocation(d.selectedOptions[0])}>
          <Option value='Online'>Online</Option>
          {flags.map((flag, index) => (
            //@ts-ignore
            <Option key={index} value={flag.country}>
              <ReactCountryFlag
                countryCode={flag.code!}
                svg
                cdnSuffix="svg"
                title="US"
              />
              {flag.country}
            </Option>
          ))}
        </Dropdown>
      </Field>
      <label htmlFor="file-input" className="file-upload-label">
        <input
          type="file"
          id="file-input"
          accept="image/*"
          onChange={handleImageChange}
          style={{ display: 'none' }}
        />
        <span className="file-upload-text">Upload Images</span>
      </label>
      <div className="image-preview">
        {image && (
          <ImagePreview
            src={URL.createObjectURL(image!)}
            index={Math.random()}
            remove={() => setImage(undefined)}
          />
        )}
      </div>

      <Button className="submit-button" onClick={handleSubmit} >Submit</Button>
    </Card>
    </div>

  );
};
