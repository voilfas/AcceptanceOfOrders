export interface Order {
    orderId: string;
    orderNumber: string;
    senderCity: string;
    senderAddress: string;
    receiverCity: string;
    receiverAddress: string;
    weight: number;
    pickUpDate: string;
}