import { Base } from "./base.model";
import { TransactionType } from "./transaction-type.model";

export interface Transaction extends Base {
    amount?: number;
    description?: string;
    referenceNumber?: string;
    transactionTypeId?: string;
    transactionDate?: Date;
    transactionType?: TransactionType;

    paymentType?: 'Debit' | 'Credit' | undefined | string;
}