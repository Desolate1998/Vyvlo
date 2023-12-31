import './authenticationView.css';
import {
    Button, Field, Persona, Switch, Dialog,
    DialogTrigger,
    Input,
    ProgressBar
} from '@fluentui/react-components';
import { FormikErrors, useFormik } from 'formik';
import { Registerform } from './Registerform';
import { loginRequest } from '../../Domain/Contracts/Authentication/Login/loginRequest';
import { useState } from 'react';
import { authenticationApi } from '../../Infrastructure/API/Requests/Authentication/authenticationApi';
import { addNotification } from '../../Infrastructure/helpers/notificationHelper';
import { useAuth } from '../../Infrastructure/Contexts/AuthContext';

export const AuthenticationView = () => {
    const [loading, setLoading] = useState<boolean>(false);
    const {login} = useAuth()

    const formik = useFormik<loginRequest>({
        initialValues: {
            email: '',
            password: '',
        },
        validateOnChange: false,
        validateOnBlur: false,
        validateOnMount: false,
        onSubmit: async (data) => {
            setLoading(true)
            try {
                var response = await authenticationApi.login(data);
                if (response.isError) {
                    addNotification(response.firstError.description, 'danger')
                } else {
                    login(response.value)
                }
            } catch (error) {
                addNotification('Internal Server Error', 'danger')
            } finally {
                setLoading(false)
            }
        },
        validate: (values: loginRequest) => {
            let errors: FormikErrors<loginRequest> = {};
            if (!values.email) {
                errors.email = 'Email is required';
            } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
                errors.email = 'Invalid email address';
            }

            if (!values.password) {
                errors.password = 'Password is required';
            }

            return errors;
        },
    });

    return (
        <div className='view-body'>
            <div className='account-continer'>
                <Persona size='huge' />
                <Field placeholder='Enter your email address' className='input-container' label='Email' validationMessage={formik.errors.email}>
                    <Input aria-label='Email' name='email'
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.email}
                        disabled={loading}
                         />
                </Field>
                <Field placeholder='Enter your password' className='input-container' label='Password' validationMessage={formik.errors.password}>
                    <Input aria-label='Password' type='password' name='password'
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.password} 
                        disabled={loading}
                        />
                </Field>
                   {loading && <ProgressBar className='login-progress'/>}
                <div className='label-container'>
                    <Switch disabled={loading} label='Remember me' />
                    <Button disabled={loading} aria-label='Forgot Password' appearance='transparent'>Forgot Password</Button>
                </div>

                <div className='button-container'>
                    <Button aria-label='Login' appearance='primary' className='login-button' onClick={formik.submitForm}>Login</Button>
                    <Dialog>
                        <DialogTrigger disableButtonEnhancement>
                            <Button disabled={loading} aria-label='Need Account?' appearance='secondary'>Need Account?</Button>
                        </DialogTrigger>
                        <Registerform />
                    </Dialog>
                </div>
            </div>
        </div>
    );
};
