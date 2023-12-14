import React, { useState } from 'react';
import { Panel, PanelType } from '@fluentui/react/lib/Panel';
import { Formik, Form } from 'formik';
import { Button, Field, Input, Textarea } from "@fluentui/react-components";
import { Drawer, DrawerBody, DrawerFooter, DrawerHeader, DrawerHeaderTitle } from '@fluentui/react-components/unstable';
import { Dismiss24Regular } from '@fluentui/react-icons';

interface CreateStoreProps {
    isOpen: boolean;
    onClose: () => void;
}

const CreateStore: React.FC<CreateStoreProps> = ({ isOpen, onClose }) => {
    const [name, setName] = useState<{value:string,error?:string}>({value:''});
    const [description, setDescription] = useState<{value:string,error?:string}>({value:''});

    const handleSubmit = () => {
        if(name.value.length < 3){
            setName({...name,error:'Name must be at least 3 characters long'})
        }
        if(description.value.length < 15){
            setDescription({...description,error:'Description must be at least 15 characters long'})
        }
    };

    return (
        <Drawer
            open={isOpen}
            onOpenChange={onClose}
            position="end"
        >
            <DrawerHeader>
                <DrawerHeaderTitle
                    action={
                        <Button
                            appearance="subtle"
                            aria-label="Close"
                            icon={<Dismiss24Regular />}
                            onClick={onClose}
                        />
                    }
                >
                    Create New Store
                </DrawerHeaderTitle>
            </DrawerHeader>
            <DrawerBody>
                <Field
                    label="Name"
                    validationMessage={name.error}
                >
                    <Input value={name.value} onChange={event => setName({value:event.target.value})} />
                </Field>

                <Field
                    label="Description"
                    validationMessage={description.error}
                >
                    <Textarea rows={5} maxLength={500} value={description.value} onChange={event => setDescription({value:event.target.value})} />
                </Field>
            </DrawerBody>
            <DrawerFooter>
                <Button onClick={onClose}>Cancel</Button>
                <Button appearance="primary" onClick={handleSubmit}>Create</Button>
            </DrawerFooter>
        </Drawer>
    );
};

export default CreateStore;
