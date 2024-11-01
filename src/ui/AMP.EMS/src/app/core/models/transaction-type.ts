import { Transaction } from "./transaction";

export interface TransactionType {
    id?: string;
    name?: string;
    description?: string;

    transactions?: Transaction[];
}