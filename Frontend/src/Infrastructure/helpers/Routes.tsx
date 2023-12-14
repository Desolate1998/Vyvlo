import { Icon } from "@fluentui/react/lib/Icon";
import { Route } from "react-router-dom";
import Dashboard from "../../Views/Dashboard/Dashboard";
import { Menu } from "../../Domain/Types/Common/menu";

export const routes:Menu[] = [
    {
        name: "Main Navigation",
        visable:true,
        subMenu: [
            {
                name: "Dashboard",
                url: "/",
                visable: true,
                icon: <Icon iconName="ViewDashboard" />,
                component: <Dashboard /> 
            },
        ]
    }
];

export const generateRoutes = (menuItems: any[]): any => {
    return menuItems.map((item: any) => {
      if (item.subMenu != null) {
        return generateRoutes(item.subMenu);
      } else {
        return <Route key={item.url} path={item.url} element={item.component} />;
      }
    });
  };