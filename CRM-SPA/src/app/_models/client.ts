import { Order } from './order';

export interface Client {
    id: number;
    name: string;
    phone: string;
    email: string;
    createdAt: Date;
    ordersCount: number;
    orders: Order[];
}
