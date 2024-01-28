import { Button, Input, Textarea, Spinner, Field } from '@fluentui/react-components';
import { MessageBar, MessageBarType } from '@fluentui/react';
import { Drawer, DrawerHeader, DrawerHeaderTitle, DrawerBody, DrawerFooter } from '@fluentui/react-components/unstable';
import { Dismiss24Regular } from '@fluentui/react-icons';
import React, { useEffect, useState } from 'react'
import { storeApi } from '../../../Infrastructure/API/Requests/Store/storeApi';
import { useStore } from '../../../Infrastructure/Contexts/StoreContext';
import { productCategoryApi } from '../../../Infrastructure/API/Requests/ProductCategory/productCategoryApi';
import { useToaster } from '../../../Infrastructure/Contexts/ToasterContext';

interface IProps {
    isOpen: boolean;
    onClose: () => void;
}


export const CreateProductCategory:React.FC<IProps> = ({ isOpen, onClose })=> {
    const [name, setName] = useState<{ value: string, error?: string }>({ value: '' });
    const [description, setDescription] = useState<{ value: string, error?: string }>({ value: '' });
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const { currentStoreId } = useStore();
  

    const handleClose = () => {
        setName({ value: '' });
        setDescription({ value: '' });
        setError(null);
        onClose();
    }


    const handleSubmit = async () => {
        let submit: boolean = true;

        if (name.value.length < 3) {
            setName({ ...name, error: 'Name must be at least 3 characters long' })
            submit = false;
        }
        if (description.value.length < 3) {
            setDescription({ ...description, error: 'Description must be at least 3 characters long' })
            submit = false;
        }
        if (submit === true) {
            setIsLoading(true)
            setError(null)
            try {
                var response = await productCategoryApi.create({ name: name.value, description: description.value, storeId: currentStoreId!  });
                if (response.isError) {
                    setError(response.firstError.description);
                } else {
                    handleClose();
                }
            } catch (error) {
                console.log(error)
                setError('Internal server error');
            } finally {
                setIsLoading(false)
            }
        }
    };

    return (
        <Drawer
            open={isOpen}
            onOpenChange={isLoading ? () => { } : handleClose}
            position="end"
        >
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
                    Create New Product Categegory
                </DrawerHeaderTitle>
            </DrawerHeader>
            <DrawerBody>
                <Field label="Name" validationMessage={name.error}>
                    <Input autoComplete='undefiend' disabled={isLoading} value={name.value} onChange={event => setName({ value: event.target.value })} />
                </Field>
                <Field label="Description" validationMessage={description.error} >
                    <Textarea rows={5} disabled={isLoading} maxLength={500} value={description.value} onChange={event => setDescription({ value: event.target.value })} />
                </Field>
                <br />
                {error && (
                    <MessageBar  messageBarType={MessageBarType.error}>
                        {error}
                    </MessageBar>
                )}
            </DrawerBody>
            <DrawerFooter>
                <Button disabled={isLoading} onClick={handleClose}>Cancel</Button>
                <Button appearance="primary" disabled={isLoading} onClick={handleSubmit}> {isLoading ? <Spinner style={{ maxHeight: '20px' }} /> : 'Submit'}</Button>
            </DrawerFooter>
        </Drawer>
    );
}
