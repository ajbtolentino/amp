import { Account } from "./account";
import { TransactionType } from "./transaction-type";

export interface Transaction {
    id?: string;
    accountId?: string;
    transactionTypeId?: string;

    account: Account;
    transactionType?: TransactionType;
}