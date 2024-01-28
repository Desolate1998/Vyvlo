import { DialogTrigger, Button, DialogSurface, DialogBody, DialogTitle, DialogContent, Input, DialogActions, Field, ProgressBar } from '@fluentui/react-components'
import { registerRequest } from '../../Infrastructure/Types/registerRequest';
import { FormikErrors, useFormik } from 'formik';
import { authenticationApi } from '../../Infrastructure/API/Requests/Authentication/authenticationApi';
import { useState } from 'react';

export const Registerform = () => {
  const [loading, setLoading] = useState<boolean>(false);

  const formik = useFormik<registerRequest>({
    initialValues: {
      email: '',
      firstName: '',
      lastName: '',
      password: '',
    },
    validateOnChange: false,
    validateOnBlur: false,
    validateOnMount: false,
    onSubmit: async (data) => {
      try {
        setLoading(true)
        var respponse = await authenticationApi.register(data)
        if (respponse.isError) {
        } else {
        }
      } catch (error) {
      } finally {
        setLoading(false)
      }
    },
    validate: (values: registerRequest) => {
      let errors: FormikErrors<registerRequest> = {};

      if (!values.email) {
        errors.email = 'Email is required';
      } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(values.email)) {
        errors.email = 'Invalid email address';
      }

      if (!values.firstName) {
        errors.firstName = 'First Name is required';
      }

      if (!values.lastName) {
        errors.lastName = 'Last Name is required';
      }

      if (!values.password) {
        errors.password = 'Password is required';
      } else if (values.password.length < 6) {
        errors.password = 'Password must be at least 6 characters long';
      }

      return errors;
    },

  });

  return (
    <DialogSurface>
      <DialogBody>
        <DialogTitle>Register</DialogTitle>
        <DialogContent className='register-container'>
          <Field className='input-container' label='Email' validationMessage={formik.errors.email}>
            <Input
              aria-label='Email'
              placeholder='Enter your email address...'
              name='email'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.email}
              disabled={loading}
            />
          </Field>
          <Field className='input-container' label='First Name' validationMessage={formik.errors.firstName}>
            <Input
              aria-label='First Name'
              placeholder='Enter your first name...'
              name='firstName'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.firstName}
              disabled={loading}
            />
          </Field>

          <Field className='input-container' label='Last Name' validationMessage={formik.errors.lastName}>
            <Input
              aria-label='Last Name'
              placeholder='Enter your last name...'
              name='lastName'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.lastName}
              disabled={loading}
            />
          </Field>
          <Field className='input-container' label='Password' validationMessage={formik.errors.password}>
            <Input
              aria-label='Password'
              type='password'
              placeholder='Enter your password...'
              name='password'
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              value={formik.values.password}
              disabled={loading}
            />
          </Field>
          {loading && <ProgressBar />}
          <p>
            By registering you agree to the term and conditions found
            <a href="https://th.bing.com/th/id/R.df0a9b63b131e1bf4d6b4bf129d64051?rik=53yLZbOA6Ct3Vw&riu=http%3a%2f%2fimg.kelbymediagroup.com%2fscottkelby%2fwp-content%2fuploads%2f2015%2f10%2f1_markrodriguez.jpg&ehk=I8fkr37dPpyM7VNNXUQnu15QGeYXcVhhn4uGU3mzz4Y%3d&risl=&pid=ImgRaw&r=0" rel="new" target='blank'>
              here
            </a>
          </p>
        </DialogContent>
        <DialogActions>
          <DialogTrigger disableButtonEnhancement>
            <Button aria-label='Close' appearance="secondary" disabled={loading}>Close</Button>
          </DialogTrigger>
          <Button aria-label='Register' appearance="primary" onClick={formik.submitForm} disabled={loading}>Register</Button>
        </DialogActions>
      </DialogBody>
    </DialogSurface>
  );
}
