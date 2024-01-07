import { Store } from 'react-notifications-component';

export function addNotification(title: string, message: string, type: 'success' | 'danger' | 'info' | 'default' | 'warning' | 'primary' | 'secondary' | 'dark' | 'light' = 'success') {
    Store.addNotification({
        title,
        message,
        //@ts-ignore
        type: type,
        insert: "top",
        container: "top-right",
        animationIn: ["animate__animated", "animate__fadeIn"],
        animationOut: ["animate__animated", "animate__fadeOut"],
        dismiss: {
            duration: 5000,
            onScreen: true
        }
    });
}
