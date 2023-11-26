import React from 'react'
import { IMenu, MenuSection } from './Menu/MenuSection';
import logo from '../../assets/Images/Work Mark Black.png'
import { Card, Avatar } from '@fluentui/react-components';
import './sidebar.css'

import { useMenu } from '../../Infrastructure/Contexts/MenuContext';
interface IProps {
  menuOptions: IMenu[]
}

export const SideMenu: React.FC<IProps> = ({ menuOptions }) => {
  const { isMenuOpen } = useMenu();
  
  return (
    <Card className={`sidebar ${isMenuOpen ? 'open' : 'closed'}`}>
      <div className='menuContainer'>
        <img src={logo} style={{ width: '100%' }} />
        {menuOptions.filter(x => x.visable).map(item => {
          return (
            <MenuSection options={item} />
          )
        })
        }
      </div>
    </Card>
  )
}
