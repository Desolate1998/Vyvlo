import { SubMenu } from "./SubMenu";

export type Menu =  {
    name: string;
    subMenu: SubMenu[];
    visable: boolean;
    accessCode?: string | null;
  }
  
