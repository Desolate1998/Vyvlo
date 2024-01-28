import { Button, Card, Field, Table, TableBody, TableCell, TableCellLayout, TableHeader, TableHeaderCell, TableRow, Input, Text, Toaster, ProgressBar } from '@fluentui/react-components'
import React, { useEffect, useState } from 'react'
import { CreateProductCategory } from './CreateProductCategory/CreateProductCategory';
import { productCategoryApi } from '../../Infrastructure/API/Requests/ProductCategory/productCategoryApi';
import { useStore } from '../../Infrastructure/Contexts/StoreContext';
import { CategoriesWithStats } from '../../Infrastructure/Types/GetAllCategoriesWithStats';
import {
  Edit24Regular,
  Delete24Regular,
  PictureInPictureExit16Regular
} from "@fluentui/react-icons";
import { useToaster } from '../../Infrastructure/Contexts/ToasterContext';

export const ManageCategoriesView = () => {
  const [open, setOpen] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [categories, setCategories] = useState<CategoriesWithStats[]>([]);
  const [editItem, setEditItem] = useState<CategoriesWithStats | null>(null);
  const [search, setSearch] = useState<string>('');

  const { currentStoreId } = useStore();
  const { mainToast, notify } = useToaster();

  useEffect(() => {
    getItems();
  }, [currentStoreId])

  const getItems = async () => {
    setIsLoading(true)
    try {
      var items = await productCategoryApi.getAllCategoriesWithStats(currentStoreId!);
      if (!items.isError) {
        setCategories([...items.value!])
      } else {
        notify(items.firstError.description, 'error');
      }
    } catch (error) {
      notify("Internal Server Error", 'error');
    } finally {
      setIsLoading(false)
    }
  }

  const close = () => {
    setOpen(false)
    getItems();
  }

  const makeEdit = (record: CategoriesWithStats) => {
    setEditItem(record)
  }

  const deleteItem = async (id: number) => {
    setIsLoading(true)
    try {
      var results = await productCategoryApi.deleteCategory(id);
      if (!results.isError) {
        notify('success', 'success')
        setCategories(categories.filter(x => x.productCategoryId != id))
      } else {
        notify(results.firstError.description, 'error');
      }
    } catch (error) {
      notify("Internal Server Error", 'error');
    } finally {
      setIsLoading(false)
    }
  }

  const updateItem = async () => {
    setIsLoading(true)
    try {
      var results = await productCategoryApi.updateCategory({
        description: editItem!.description,
        id: editItem!.productCategoryId,
        name: editItem!.name,
      });
      if (!results.isError) {
        notify('success', 'success')
        setCategories(categories.map(x => {
          if (x.productCategoryId == editItem?.productCategoryId) {
            return editItem!;
          }
          return x;
        }))
        setEditItem(null);
      } else {
        notify(results.firstError.description, 'error');
      }
    } catch (error) {
      notify("Internal Server Error", 'error');
    } finally {
      setIsLoading(false)
    }
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
      <CreateProductCategory isOpen={open} onClose={close} />
      <Card>
        <div>
          <Field label="Search">
            <Input appearance="outline" style={{ width: '100%' }} value={search} onChange={(_,v)=>setSearch(v.value)}  />
          </Field>
          <Button appearance='primary' onClick={() => setOpen(true)} style={{ marginTop: 5 }}>Add New Category</Button>
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
                Product
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
          <TableBody>
            {categories.filter(x=>x.description.includes(search) ||x.name.includes(search) ) .map((category, index) => {
              if (category.productCategoryId == editItem?.productCategoryId) return (
                <TableRow appearance={index % 2 == 0 ? 'none' : 'neutral'} key={category.productCategoryId}>
                  <TableCell >
                    <Input appearance="outline" value={editItem.name} style={{ width: '100%' }} onChange={(_, s) => setEditItem({ ...editItem, name: s.value })} />
                  </TableCell>
                  <TableCell>
                    <Input appearance="outline" value={editItem.description} style={{ width: '100%' }} onChange={(_, s) => setEditItem({ ...editItem, description: s.value })} />
                  </TableCell>
                  <TableCell>{category.totalProducts}</TableCell>
                  <TableCell>{category.totalStock}</TableCell>
                  <TableCell>
                    <Button disabled={isLoading} style={{ backgroundColor: '#ffbd03', color: 'white', marginRight: '5px' }} appearance='primary' icon={<PictureInPictureExit16Regular />} onClick={() => setEditItem(null)}>Cancel</Button>
                    <Button disabled={isLoading} style={{ backgroundColor: '#50c878', color: 'white' }} appearance='primary' onClick={updateItem} icon={<PictureInPictureExit16Regular />}>Confirm</Button>
                  </TableCell>
                  <TableCell>
                    <Button onClick={() => deleteItem(category.productCategoryId)} style={{ backgroundColor: '#c1121f', color: 'white' }} appearance='subtle' icon={<Delete24Regular style={{ color: 'white' }} />}>Delete</Button>
                  </TableCell>
                </TableRow>
              )

              return (
                <TableRow appearance={index % 2 == 0 ? 'none' : 'neutral'} key={category.productCategoryId}>
                  <TableCell >
                    {category.name}
                  </TableCell>
                  <TableCell><Text style={{ maxWidth: "100%" }}>{category.description}</Text></TableCell>
                  <TableCell>{category.totalProducts}</TableCell>
                  <TableCell>{category.totalStock}</TableCell>
                  <TableCell>
                    <Button appearance='primary' icon={<Edit24Regular />} onClick={() => makeEdit(category)}>Edit</Button>
                  </TableCell>
                  <TableCell>
                    <Button onClick={() => deleteItem(category.productCategoryId)} style={{ backgroundColor: '#c1121f', color: 'white' }} appearance='subtle' icon={<Delete24Regular style={{ color: 'white' }} />}>Delete</Button>
                  </TableCell>
                </TableRow>
              )
            })}
          </TableBody>
        </Table >
      </Card>
    </>
  )
}
