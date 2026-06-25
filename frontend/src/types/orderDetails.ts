export interface OrderDetails {
    id: string;
    orderNumber: string;
    senderCity: string;
    senderAddress: string;
    receiverCity: string;
    receiverAddress: string;
    weight: number;
    pickUpDate: string;
    createdAt: string;
}