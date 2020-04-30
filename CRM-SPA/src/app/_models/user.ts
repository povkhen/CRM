import { Photo } from './photo';
import { Service } from './service';

export interface User {
    id: number;
    login: string;
    fullName: string;
    position: string;
    email: string;
    phone: string;
    age: number;
    gender: string;
    createdAt: Date;
    lastActive: Date;
    photoURL: string;
    adress: string;
    departmentName?: string;
    departmentPhone?: string;
    photos?: Photo[];
    userServices: Service[];
}
