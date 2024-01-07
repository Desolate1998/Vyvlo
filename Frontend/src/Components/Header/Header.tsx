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
    Dropdown,
    Option
} from "@fluentui/react-components";
import { HiMenuAlt1, HiMenuAlt4 } from "react-icons/hi";
import "./header.css";
import { useMenu } from "../../Infrastructure/Contexts/MenuContext";
import { useAuth } from "../../Infrastructure/Contexts/AuthContext";
import { useTheme } from "../../Infrastructure/Contexts/ThemeContext";
import { LightTheme } from "../../Infrastructure/Themes/lightTheme";
import { DarkTheme } from "../../Infrastructure/Themes/darkTheme";
import { useEffect, useState } from "react";
import { Icon } from "@fluentui/react/lib/Icon";
import CreateStore from "../CreateStore/CreateStore";
import { storeApi } from "../../Infrastructure/API/Requests/Store/storeApi";
import { addNotification } from "../../Infrastructure/helpers/notificationHelper";
import { KeyValuePair } from "../../Domain/Types/Common/keyValuePair";
import { useStore } from "../../Infrastructure/Contexts/StoreContext";

export default function Header() {
    const  {setCurrentStoreId,currentStoreId, stores,getCurrentStoreName} = useStore();

    const { changeMenu, isMenuOpen } = useMenu();
    const { user } = useAuth();
    const { swapTheme, useDarkTheme } = useTheme();
   
    const {logout} = useAuth()

    const [open, setOpen] = useState<boolean>(false);

    useEffect(() => {

    }, [])

    const toggleSidebar = () => {
        changeMenu();
    };

    const changeMainStore = (key: number) => {
        if (currentStoreId != null || currentStoreId != key) {
            setCurrentStoreId(key);
        }
    }
    return (
        <div className="top-bar" style={{ backgroundColor: `${useDarkTheme ? DarkTheme.paper.backgroundColor : LightTheme.paper.backgroundColor}` }}>
            <CreateStore isOpen={open} onClose={() => { setOpen(false) }} />
            <Button icon={isMenuOpen ? <HiMenuAlt1 /> : <HiMenuAlt4 />} appearance="primary" onClick={toggleSidebar}></Button>
            <Dropdown placeholder="Select A Store"  value={getCurrentStoreName()}>
                <Option key={"Create-New-Store"} value={'Create-New-Store'} text={''} onClick={() => setOpen(true)}>
                    <Text style={{ display: 'flex', justifyContent: 'center', alignContent: 'center' }}> <Icon iconName="CircleAddition" style={{ marginRight: 10 }} />   Create New Store</Text>
                </Option>
                <Divider />
                {stores.map((option) => (<Option onClick={() => { changeMainStore(option.key) }} key={option.key} value={option.value}>{option.value}</Option>))}
            </Dropdown>
            <div style={{ marginLeft: "auto", paddingRight: "10px" }}>
                <Text className="email-address" style={{ marginRight: "10px", color: useDarkTheme ? "white" : "black" }}>{user?.firstName + ' ' +user?.lastName}</Text>
                <Popover>
                    <PopoverTrigger disableButtonEnhancement><Avatar aria-label={user?.email} /></PopoverTrigger>
                    <PopoverSurface style={{ marginRight: "100px" }}>
                        <MenuList>
                            <MenuItem>Profile</MenuItem>
                            <MenuItem>Settings</MenuItem>
                            <MenuItem>Help</MenuItem>
                            <MenuItem onClick={logout}>Logout</MenuItem>
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
