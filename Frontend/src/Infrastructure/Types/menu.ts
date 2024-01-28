import { SubMenu } from "./subMenu";

export type Menu =  {
    name: string;
    subMenu: SubMenu[];
    visable: boolean;
    accessCode?: string | null;
  }
  
