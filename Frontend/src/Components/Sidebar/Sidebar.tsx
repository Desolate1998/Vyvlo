import * as React from 'react';
import { Card } from '@fluentui/react-components';
import { useMenu } from '../../Infrastructure/Contexts/MenuContext';
import { routes } from '../../Infrastructure/helpers/Routes';
import { MenuSection } from '../MenuSection/MenuSection';
import './sidebar.css'

const Sidebar: React.FC = () => {
    const { isMenuOpen } = useMenu();
    return (
      <Card className={`sidebar ${isMenuOpen ? "open" : "closed"}`}>
          {
            routes.map((item) => {
              return <MenuSection options={item} key={item.name}/>;
            })}
      </Card>
    );
}

export default Sidebar;