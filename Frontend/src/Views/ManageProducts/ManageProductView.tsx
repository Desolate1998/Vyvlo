import { Button, Card, Field, Input, ProgressBar, Table, TableBody, TableCell, TableHeader, TableHeaderCell, TableRow, Toaster } from '@fluentui/react-components'
import React, { useEffect, useState } from 'react'
import { useStore } from '../../Infrastructure/Contexts/StoreContext';
import { useToaster } from '../../Infrastructure/Contexts/ToasterContext';
import { CreateProduct } from './CreateProduct/CreateProduct';
import { productApi } from '../../Infrastructure/API/Requests/Product/productApi';
import { Delete24Regular, Edit24Regular } from '@fluentui/react-icons';

export const ManageProductView = () => {
  const { currentStoreId } = useStore();
  const [open, setOpen] = useState(false);
  const { mainToast, notify } = useToaster();
  const [isLoading, setIsLoading] = useState(false);
  const [search, setSearch] = useState<string>('');
  const [products, setProducts] = useState<Product[]>([])

  useEffect(() => {
    getItems();
  }, [currentStoreId])

  const getItems = async () => {
    setIsLoading(true)
    try {
      var response = await productApi.getAll(currentStoreId!)
      if (response.isError) {
        notify(response.firstError.description, 'error');
      } else {
        setProducts([...response.value]);
      }
    } catch (error) {
      notify("Internal Server Error", 'error');
    } finally {
      setIsLoading(false)
    }
  }

  const closeCreateProduct = () => {
    setOpen(false)
  }

  const addProduct = (item:Product) =>{
    setProducts([...products, item]);
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
      <CreateProduct isOpen={open} onClose={closeCreateProduct} addProduct={addProduct} />
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
              <TableHeaderCell> Name</TableHeaderCell>
              <TableHeaderCell> Description</TableHeaderCell>
              <TableHeaderCell>Price</TableHeaderCell>
              <TableHeaderCell>Stock</TableHeaderCell>
              <TableHeaderCell>Edit</TableHeaderCell>
              <TableHeaderCell>Delete</TableHeaderCell>
            </TableRow>
          </TableHeader>
          <TableBody>
            {products.filter(p => p.name.toLowerCase().includes(search.toLowerCase())).map((product, index) => (
              <TableRow appearance={index % 2 == 0 ? 'none' : 'neutral'} key={product.id}>
                <TableCell>{product.name}</TableCell>
                <TableCell>{product.description}</TableCell>
                <TableCell>{product.price}</TableCell>
                <TableCell>{product.stock}</TableCell>
                <TableCell>
                  <Button appearance='primary' icon={<Edit24Regular />} >Edit</Button>
                </TableCell>
                <TableCell>
                  <Button style={{ backgroundColor: '#c1121f', color: 'white' }} appearance='subtle' icon={<Delete24Regular style={{ color: 'white' }} />}>Delete</Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table >
      </Card>
    </>
  )
}
