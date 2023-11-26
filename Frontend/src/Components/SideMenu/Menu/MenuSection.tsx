import React from 'react'
import {
  Card,
  Body1Strong,
  MenuList,
  MenuItem,
  MenuTrigger,
  MenuPopover,
  Menu
} from '@fluentui/react-components'

export interface ISubMenu {
  name: string,
  subMenu?: ISubMenu[]
}

export interface IMenu {
  name: string,
  subMenu: ISubMenu[],
  visable: boolean;
}

interface IProps {
  options: IMenu
}

export const MenuSection: React.FC<IProps> = ({ options }) => {

  return (
    <>
      <Card style={{ backgroundColor: '#457b9d', height: '30px', padding: 0, display: 'flex', justifyItems: 'center', alignItems: 'center', color: '#f1faee', marginBottom: '10px' }}>
        <Body1Strong style={{
          width: '100%',
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          paddingRight:'10px',
          paddingLeft:'10px'
        }}>{options.name}</Body1Strong>
      </Card>
      <div style={{display:'flex',height:'100vh',}}>
        <MenuList>
          {options.subMenu.map((item => {
            if (item.subMenu == null) {
              return (
                <MenuItem >{item.name}</MenuItem>
              )
            } else {
              return (
                <Menu>
                  <MenuTrigger disableButtonEnhancement>
                    <MenuItem >{item.name}</MenuItem>
                  </MenuTrigger>
                  <MenuPopover >
                    <MenuList >
                      {item.subMenu.map(subItem => {
                        return (
                          <MenuItem >{subItem.name}</MenuItem>
                        )
                      })}
                    </MenuList>
                  </MenuPopover>
                </Menu>
              )
            }
          }))}

        </MenuList>
      </div>
    </>
  )
}
