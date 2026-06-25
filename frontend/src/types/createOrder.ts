export interface CreateOrder {
    senderCity: string;
    senderAddress: string;
    receiverCity: string;
    receiverAddress: string;
    weight: number;
    pickUpDate: string;
}