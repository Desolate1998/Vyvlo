import {
    Button,
    Popover,
    PopoverTrigger,
    Avatar,
    PopoverSurface,
    MenuList,
    MenuItem,
    Text,
    Switch,
    Divider,
    Select,
    Dropdown,
    Option,
    Field,
    Input,
} from "@fluentui/react-components";
import { HiMenuAlt1, HiMenuAlt4 } from "react-icons/hi";
import "./header.css";
import { useMenu } from "../../Infrastructure/Contexts/MenuContext";
import { useAuth } from "../../Infrastructure/Contexts/AuthContext";
import { useTheme } from "../../Infrastructure/Contexts/ThemeContext";
import { LightTheme } from "../../Infrastructure/Themes/lightTheme";
import { DarkTheme } from "../../Infrastructure/Themes/darkTheme";
import { useState } from "react";
import { Icon } from "@fluentui/react/lib/Icon";
import CreateStore from "../CreateStore/CreateStore";

export default function Header() {
    const { changeMenu, isMenuOpen, page } = useMenu();
    const { user } = useAuth();
    const { swapTheme, useDarkTheme } = useTheme();
    const [stores, setStores] = useState<string[]>(['Fluffy bunny ']);
    const [open, setOpen] = useState<boolean>(false);
    

    const toggleSidebar = () => {
        changeMenu();
    };

    return (
        <div className="top-bar" style={{ backgroundColor: `${useDarkTheme ? DarkTheme.paper.backgroundColor : LightTheme.paper.backgroundColor}` }}>
            <CreateStore isOpen={open} onClose={() => {setOpen(false)}} />
            <Button icon={isMenuOpen ? <HiMenuAlt1 /> : <HiMenuAlt4 />} appearance="primary" onClick={toggleSidebar}></Button>
            <Text as="h1" size={500} color={useDarkTheme ? "white" : "black"}><span style={{ color: useDarkTheme ? "white" : "black" }}>{page}</span></Text>
            <Dropdown placeholder="Select A Store">
                <Option key={"Create-New-Store"} value={'Create-New-Store'} text={''} onClick={()=>setOpen(true)}>
                    <Text style={{ display: 'flex', justifyContent: 'center', alignContent: 'center' }}> <Icon iconName="CircleAddition" style={{ marginRight: 10 }} />   Create New Store</Text>
                </Option>
                <Divider />
                {stores.map((option) => (<Option key={option} value={option}>{option}</Option>))}
            </Dropdown>
            <div style={{ marginLeft: "auto", paddingRight: "10px" }}>
                <Text className="email-address" style={{ marginRight: "10px", color: useDarkTheme ? "white" : "black" }}>{user?.email}</Text>
                <Popover>
                    <PopoverTrigger disableButtonEnhancement><Avatar aria-label={user?.email} /></PopoverTrigger>
          
                    <PopoverSurface style={{ marginRight: "100px" }}>
                    <Field
                label="Example field"
                validationState="success"
                validationMessage="This is a success message."
            >
                <Input />
            </Field>
                        <MenuList>
                            <MenuItem>Profile</MenuItem>
                            <MenuItem>Settings</MenuItem>
                            <MenuItem>Help</MenuItem>
                            <MenuItem>Logout</MenuItem>
                            <Divider />
                            <MenuItem>
                                <Switch
                                    checked={useDarkTheme}
                                    onClick={swapTheme}
                                    label="Dark Theme"
                                />
                            </MenuItem>
                        </MenuList>
                    </PopoverSurface>
                </Popover>
            </div>
        </div>
    );
}
