import { User } from './user';
import { Client } from './Client';

export interface Order {
    id: number;
    createOn: Date;
    executionStatus: number;
    country: string;
    city: string;
    street: string;
    buildingNumber: string;
    comment: string;
    executionDate: string;
    modifiedOn: string;
    sum: number;

    vendor: User;
    executor: User;
    owner: Client;
}
