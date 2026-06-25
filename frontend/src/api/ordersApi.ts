import axios from "axios";
import type {Order} from "../types/order.ts";
import type {OrderDetails} from "../types/orderDetails.ts";

export const api = axios.create({
    baseURL: "http://localhost:8080/api"
});

export async function getOrders(): Promise<Order[]>
{
    const responce = await api.get("/orders");
    
    return responce.data;
}

export async function getOrderById(id: string): Promise<OrderDetails> {
    const responce = await api.get<OrderDetails>(`orders/${id}`);
    
    return responce.data;
}
