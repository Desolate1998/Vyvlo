export type SubMenu = {
    name: string;
    url?: string;
    accessCode?: string | null;
    component?: JSX.Element;
    visable: boolean;
    subMenu?: SubMenu[];
    icon?: any;
  }
  