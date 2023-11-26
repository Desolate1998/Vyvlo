import { Button, Popover, PopoverTrigger, Avatar, PopoverSurface, MenuList, MenuItem, Text } from '@fluentui/react-components'
import { useState } from 'react'
import { HiMenuAlt1, HiMenuAlt4 } from 'react-icons/hi'
import './topbar.css'
import { useMenu } from '../../Infrastructure/Contexts/MenuContext';

export default function Topbar() {
  const { changeMenu,isMenuOpen } = useMenu();
  const toggleSidebar = () => {
    changeMenu()
  };

  return (
    <div className="top-bar">
      <div>
        <Button
          icon={isMenuOpen ? <HiMenuAlt1 /> : <HiMenuAlt4 />}
          appearance='primary'
          onClick={toggleSidebar}>
        </Button>
      </div>
      <div style={{ marginLeft: '10px' }}>
        <Text as='h1' size={500}>EFT Realtime Dashboard</Text>
      </div>

      <div></div>

      <div style={{ right: 0, display: 'flex', alignItems: 'center' }}>
        <Text style={{ marginRight: '10px' }}>Ruan de Jongh</Text>
        <Popover>
          <PopoverTrigger disableButtonEnhancement>
            <Avatar aria-label="Ruan de Jongh" />
          </PopoverTrigger>
          <PopoverSurface >
            <MenuList >
              <MenuItem>Profile</MenuItem>
              <MenuItem>Settings</MenuItem>
              <MenuItem>Help</MenuItem>
              <MenuItem>Logout</MenuItem>
            </MenuList>
          </PopoverSurface>
        </Popover>
      </div>
    </div>
  )
}
