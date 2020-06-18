import { Photo } from './photo';
import { Service } from './service';

export interface User {
    id: number;
    userName: string;
    fullName: string;
    position: string;
    email: string;
    phone: string;
    age: number;
    gender: string;
    createdAt: Date;
    lastActive: any;
    photoURL: string;
    country: string;
    city: string;
    departmentName?: string;
    departmentPhone?: string;
    photos?: Photo[];
    userServices: Service[];
    roles?: string[];
}
