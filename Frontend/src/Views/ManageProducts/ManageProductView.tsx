import { Button, Card, Field, Input } from '@fluentui/react-components'
import React from 'react'

export const ManageProductView = () => {
  return (
    <Card>
      <div>

      <Field placeholder='Search For Product' className='input-container' label='Search For Product' >
        <Input aria-label='Search For Product' name='SearchForProduct'/>
      </Field>
      <Button>Add New Product</Button>
      </div>

    </Card>
  )
}
