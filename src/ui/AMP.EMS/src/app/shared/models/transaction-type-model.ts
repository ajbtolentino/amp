import { Transaction } from "./transaction-model";

export interface TransactionType {
    id?: string;
    name?: string;
    description?: string;

    transactions?: Transaction[];
}