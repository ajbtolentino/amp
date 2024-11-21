export interface PagedResult<T> {
    result?: T[];
    pageNumber?: number;
    totalRecords?: number;
}