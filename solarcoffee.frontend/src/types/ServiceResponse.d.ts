export interface IServiceResponse<T> {
    Data: T;
    Time: Date;
    Message: string;
    IsSuccess: boolean;
}