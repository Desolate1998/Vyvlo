import React from "react";
import {
  MenuList,
  MenuItem,
  MenuTrigger,
  MenuPopover,
  Menu,
} from "@fluentui/react-components";
import { Link } from "react-router-dom";
import { useMenu } from "../../Infrastructure/Contexts/MenuContext";
import { useTheme } from "../../Infrastructure/Contexts/ThemeContext";
import { Menu as MenuType } from "../../Infrastructure/Types/menu";

interface IProps {
  options: MenuType;
}
export const MenuSection: React.FC<IProps> = ({ options }) => {
  const { changePage } = useMenu();
  const { useDarkTheme } = useTheme();
  return (
    <>
      <div style={{ display: "flex", height: "100vh", marginTop: "10px" }}>
        <MenuList style={{ width: "100%" }}>
        <div style={{width:'100%'}}>{options.name}</div>
          {options.subMenu.map((item) => {
            if (item.subMenu == null || item.subMenu.length == 0) {
              return (
                <MenuItem key={item.url}  onClick={() => changePage(item.name)}>
                  <Link
                    style={{
                      color: useDarkTheme ? "white" : "black",
                      textDecoration: "none",
                      display: "flex",
                      gap: "10px",
                      alignContent: "center",
                    
                    }}
                    to={item.url!}
                  >
                    {item.icon && item.icon} {item.name}
                  </Link>
                </MenuItem>
              );
            } else {
              return (
                <Menu>
                  <MenuTrigger disableButtonEnhancement>
                    <MenuItem
                      style={{
                        color: useDarkTheme ? "white" : "black",
                        textDecoration: "none",
                        display: "flex",
                        gap: "10px",
                        alignContent: "center",
                        
                      }}
                    >
                      {item.icon && item.icon} {item.name}
                    </MenuItem>
                  </MenuTrigger>
                  <MenuPopover>
                    <MenuList>
                      {item.subMenu.map((subItem) => {
                        return (
                          <MenuItem>
                            <Link
                              style={{
                                color: useDarkTheme ? "white" : "black",
                                textDecoration: "none",
                                display: "flex",
                                gap: "10px",
                                alignContent: "center",
                              }}
                              to={subItem.url!}
                            >
                              {subItem.icon && subItem.icon}
                              {subItem.name}
                            </Link>
                          </MenuItem>
                        );
                      })}
                    </MenuList>
                  </MenuPopover>
                </Menu>
              );
            }
          })}
        </MenuList>
      </div>
    </>
  );
};