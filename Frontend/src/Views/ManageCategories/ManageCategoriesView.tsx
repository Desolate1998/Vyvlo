import { Button, Card, Field, Table, TableBody, TableCell, TableCellLayout, TableHeader, TableHeaderCell, TableRow, Input } from '@fluentui/react-components'
import React from 'react'

export const ManageCategoriesView = () => {
  return (
    <Card>
      <Field label="Search">
        <div>
        <Input appearance="outline" style={{width:'90%' ,marginRight:'1%'}}/>
        <Button appearance='primary'>Add New Category</Button>
        </div>
      </Field>
      <Table >
        <TableHeader>
          <TableRow appearance='neutral'>
            <TableHeaderCell>
              name
            </TableHeaderCell>
            <TableHeaderCell>
              Description
            </TableHeaderCell>
            <TableHeaderCell>
              Products
            </TableHeaderCell>
            <TableHeaderCell>
              Stock
            </TableHeaderCell>
            <TableHeaderCell>
              Action
            </TableHeaderCell>
          </TableRow>
        </TableHeader>
        <TableBody>
          <TableRow>
          </TableRow>
        </TableBody>
      </Table >
    </Card>
  )
}
