import { Icon } from "@fluentui/react/lib/Icon";
import { Route } from "react-router-dom";
import Dashboard from "../../Views/Dashboard/Dashboard";
import { Menu } from "../Types/menu";
import { ManageStoreView } from "../../Views/ManageStore/ManageStoreView";
import { ManageProductView } from "../../Views/ManageProducts/ManageProductView";
import { ManageCategoriesView } from "../../Views/ManageCategories/ManageCategoriesView";

export const routes: Menu[] = [
  {
    name: "Main Navigation",
    visable: true,
    subMenu: [
      {
        name: "Dashboard",
        url: "/",
        visable: true,
        icon: <Icon iconName="ViewDashboard" />,
        component: <Dashboard />
      },
      {
        name:"Manage Store",
        url:"/manage-store",
        visable: true,
        icon: <Icon iconName="TaskManager" />,
        component: <ManageStoreView />
      },
      {
        name:"Manage Products",
        url:"/manage-products",
        visable: true,
        icon: <Icon iconName="ProductVariant" />,
        component: <ManageProductView />
      },
      {
        name:"Manage Category",
        url:"/manage-category",
        visable: true,
        icon: <Icon iconName="ProductCatalog" />,
        component: <ManageCategoriesView />
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