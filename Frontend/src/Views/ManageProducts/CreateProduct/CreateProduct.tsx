import React, { ChangeEvent, useEffect, useState } from 'react';
import {
  Button,
  Input,
  Textarea,
  Spinner,
  Field,
  Dropdown,
  Option,
  Checkbox,
  Toaster,
  TagGroup,
  Tag,
  TagGroupProps,
} from '@fluentui/react-components';
import {
  Drawer,
  DrawerHeader,
  DrawerHeaderTitle,
  DrawerBody,
  DrawerFooter,
} from '@fluentui/react-components/unstable';
import { Dismiss24Regular } from '@fluentui/react-icons';
import ImagePreview from '../../../Components/ImagePreviewer/ImagePreviewer';
import { useToaster } from '../../../Infrastructure/Contexts/ToasterContext';
import { useStore } from '../../../Infrastructure/Contexts/StoreContext';
import { productCategoryApi } from '../../../Infrastructure/API/Requests/ProductCategory/productCategoryApi';
import { productApi } from '../../../Infrastructure/API/Requests/Product/productApi';

interface IPorps {
  isOpen: boolean;
  onClose: () => void;
  addProduct: (item: Product) => void;  
}

export const CreateProduct: React.FC<IPorps> = ({ isOpen, onClose, addProduct }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [images, setImages] = useState<File[]>([]);
  const [submitMessage, setSubmitMessage] = useState<string | null>(null);
  const [productName, setProductName] = useState<string>('');
  const [productDescription, setProductDescription] = useState<string>('');
  const [metaTags, setMetaTags] = useState<string[]>([]);
  const [price, setPrice] = useState<number | string>('');
  const [enableStockTracking, setEnableStockTracking] = useState<boolean>(false);
  const [stock, setStock] = useState<number | string>('');
  const [metaTag, setmetaTag] = useState<string>('')
  const [categories, setCatgories] = useState<ProductCategory[]>([])
  const [selectedCategory, setSelectedCatgories] = useState<ProductCategory[]>([])
  const { currentStoreId } = useStore()
  const { notify, mainToast } = useToaster()

  useEffect(() => {
    const getProductCategories = async () => {
      try {
        var results = await productCategoryApi.getAllCategories(currentStoreId!);
        if (results.isError) {
          notify(results.firstError.description, 'error')
        } else {
          setCatgories([...results.value!])
        }

      } catch (error) {
        notify('internal server error', 'error')

      } finally {

      }
    }

    getProductCategories()
  }, [currentStoreId])

  const handleImageChange = async (e: ChangeEvent<HTMLInputElement>) => {
    setIsLoading(true);
    await new Promise(resolve => setTimeout(resolve, 100));
    loadImages(e);
    setIsLoading(false);
  };

  const loadImages = (e: ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setImages(prevImages => [...prevImages, ...e.target.files!]);
    }
  };

  const removeItem: TagGroupProps["onDismiss"] = (_e, { value }) => {
    setMetaTags([...metaTags].filter((tag) => tag !== value));
  };

  const handleClose = () => {
    
    setImages([]);
    setProductName('');
    setProductDescription('');
    setMetaTags([]);
    setPrice('');
    setEnableStockTracking(false);
    setStock('');
    setSubmitMessage(null);
    onClose();
  };

  const handleSubmit = async () => {
    try {
      setIsLoading(true);
      setSubmitMessage('Product submitted successfully!');
      const formDataToSend = new FormData();
 
      formDataToSend.append('productName', productName);
      formDataToSend.append('productDescription', productDescription);
      formDataToSend.append('metaTags', metaTags.join('&A/'));
      formDataToSend.append('price', price.toString());
      formDataToSend.append('enableStockTracking', enableStockTracking.toString());
      formDataToSend.append('stock', stock.toString());
      formDataToSend.append('storeId', currentStoreId!.toString());
      formDataToSend.append('categories', selectedCategory.map(c => c.id.toString()).join('&A/'));
      images.forEach((image) => {
        formDataToSend.append(`images`, image);
      });
  
      console.log(formDataToSend.getAll('images'));
      var response = await productApi.create(formDataToSend);
      if (response.isError) {
        notify(response.firstError.description, 'error');
      } else {
        notify('Product submitted successfully!', 'success');
        addProduct(response.value!)
        handleClose();
      } 
    } catch (error) {
      notify('Internal Server Error', 'error');
    } finally {
      setIsLoading(false);
    }
  };
  
  const onCategorySelect = (data:string[]) => {
    setSelectedCatgories(categories.filter(c => data.includes(c.name)))
  }

  const removeImage = (id: number) => {
    setImages(images.filter((_, index) => index !== id));
  };

  return (
    <Drawer
      open={isOpen}
      onOpenChange={isLoading ? () => { } : handleClose}
      position="end"
      size="medium"
    >
      <Toaster
        toasterId={mainToast}
        position="top-end"
        pauseOnHover
        pauseOnWindowBlur
        timeout={1000}
      />
      <DrawerHeader>
        <DrawerHeaderTitle
          action={
            <Button
              disabled={isLoading}
              appearance="subtle"
              aria-label="Close"
              icon={<Dismiss24Regular />}
              onClick={isLoading ? () => { } : handleClose}
            />
          }
        >
          Create Product
        </DrawerHeaderTitle>
      </DrawerHeader>
      <DrawerBody>
        <Field label="Name">
          <Input
            autoComplete="undefined"
            value={productName}
            onChange={(e) => setProductName(e.target.value)}
          />
        </Field>
        <Field label="Description">
          <Textarea
            rows={5}
            disabled={isLoading}
            maxLength={500}
            value={productDescription}
            onChange={(e) => setProductDescription(e.target.value)}
          />
        </Field>

        <div>
          <div>
            {isLoading && <Spinner />}
            {images.map((image, index) => (
              <ImagePreview
                key={index}
                src={URL.createObjectURL(image)}
                index={index}
                remove={removeImage}
              />
            ))}
          </div>
        </div>
        <div className="file-upload" style={{ display: 'flex', alignItems: 'center' }}>
          <label
            htmlFor="file-input"
            className="file-upload-label"
            style={{
              backgroundColor: '#115ea3',
              color: 'white',
              padding: '10px',
              borderRadius: '5px',
              cursor: 'pointer',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              marginRight: '10px',
              boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
              transition: 'background-color 0.3s ease',
              marginTop: '10px'
            }}
          >
            <input
              type="file"
              id="file-input"
              accept="image/*"
              multiple
              onChange={handleImageChange}
              style={{ display: 'none' }}
            />
            <span className="file-upload-text"> Upload Images</span>
          </label>
        </div>
        <br />
        <Dropdown
          multiselect={true}
          placeholder="Select Categories"
      
            onOptionSelect={(_,d)=>onCategorySelect(d.selectedOptions)}
        >
          {categories.map((option) => (
            <Option key={option.id} >
              {option.name}
            </Option>
          ))}
        </Dropdown>
        <div>

          <Field label='Meta tags' >
            <Input

              value={metaTag}
              onChange={(e) => setmetaTag(e.target.value)}
            />
          </Field>
          <Button style={{ marginTop: '10px' }} onClick={() => {
            setMetaTags([...metaTags, metaTag])
            setmetaTag('')

          }}>Add Tag</Button>

        </div>
        <TagGroup style={{ marginTop: '10px' }}  onDismiss={removeItem}>
          {metaTags.map((tag) => (
            <Tag key={tag} value={tag} dismissible dismissIcon={{ "aria-label": "remove" }}>{tag}</Tag>
          ))}
        </TagGroup>
        <Field label='Price' hint='Ex 22,99'>
          <Input
            type='number'
            value={price.toString()}
            onChange={(e) => setPrice(e.target.value)}
          />
        </Field>
        <Checkbox
          label='Enable Stock Tracking'
          checked={enableStockTracking}
          onChange={(e) => setEnableStockTracking(e.target.checked)}
        />
        <Field label='Stock' >
          <Input
            type='number'
            value={stock.toString()}
            onChange={(e) => setStock(e.target.value)}
          />
        </Field>
      </DrawerBody>
      <DrawerFooter>
        <Button disabled={isLoading} onClick={handleClose}>
          Cancel
        </Button>
        <Button
          appearance="primary"
          disabled={isLoading}
          onClick={handleSubmit}
        >
          {isLoading ? (
            <Spinner style={{ maxHeight: '20px' }} />
          ) : (
            'Submit'
          )}
        </Button>
      </DrawerFooter>
    </Drawer>
  );
};
