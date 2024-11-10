import { Lookup } from "./lookup.model";
import { Transaction } from "./transaction.model";

export interface TransactionType extends Lookup {
    transactions?: Transaction[];
}