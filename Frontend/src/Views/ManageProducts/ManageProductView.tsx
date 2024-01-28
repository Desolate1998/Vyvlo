import { Button, Card, Field, Input, ProgressBar, Table, TableHeader, TableHeaderCell, TableRow, Toaster } from '@fluentui/react-components'
import React, { useEffect, useState } from 'react'
import { useStore } from '../../Infrastructure/Contexts/StoreContext';
import { useToaster } from '../../Infrastructure/Contexts/ToasterContext';
import { CreateProduct } from './CreateProduct/CreateProduct';

export const ManageProductView = () => {
  const { currentStoreId } = useStore();
  const [open, setOpen] = useState(false);
  const { mainToast, notify } = useToaster();
  const [isLoading, setIsLoading] = useState(false);
  const [search, setSearch] = useState<string>('');

  useEffect(() => {
    getItems();
  }, [currentStoreId])

  const getItems = async () => {
    setIsLoading(true)
    try {

    } catch (error) {
      notify("Internal Server Error", 'error');
    } finally {
      setIsLoading(false)
    }
  }

  const closeCreateProduct = () => {
    setOpen(false)
    
  }

  return (
    <>
      <Toaster
        toasterId={mainToast}
        position="top-end"
        pauseOnHover
        pauseOnWindowBlur
        timeout={1000}
      />
      <CreateProduct isOpen={open} onClose={closeCreateProduct} />
      <Card>
        <div>
          <Field label="Search">
            <Input appearance="outline" style={{ width: '100%' }} value={search} onChange={(_, v) => setSearch(v.value)} />
          </Field>
          <Button appearance='primary' onClick={() => setOpen(true)} style={{ marginTop: 5 }}>Add New Product</Button>
        </div>
        <div>
          {isLoading && <ProgressBar />}
        </div>
        <Table >
          <TableHeader>
            <TableRow appearance='brand'>
              <TableHeaderCell>
                Name
              </TableHeaderCell>
              <TableHeaderCell>
                Description
              </TableHeaderCell>
              <TableHeaderCell>
                Products Categories
              </TableHeaderCell>
              <TableHeaderCell>
                Stock
              </TableHeaderCell>
              <TableHeaderCell>
                Edit
              </TableHeaderCell>
              <TableHeaderCell>
                Delete
              </TableHeaderCell>
            </TableRow>
          </TableHeader>
          </Table >
      </Card>
    </>
  )
}
