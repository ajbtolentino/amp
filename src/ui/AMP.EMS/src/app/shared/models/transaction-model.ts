import { Account } from "./account.model";
import { TransactionType } from "./transaction-type-model";

export interface Transaction {
    id?: string;
    accountId?: string;
    transactionTypeId?: string;

    account: Account;
    transactionType?: TransactionType;
}