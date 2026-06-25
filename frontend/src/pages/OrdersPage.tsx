import type {Order} from "../types/order.ts";
import {useEffect, useState} from "react";
import {getOrders} from "../api/ordersApi.ts";

function OrdersPage() {
    
    const [orders, setOrders] = useState<Order[]>([]);
    
    useEffect(() => {
        loadOrders();
    }, []);
    
    async function loadOrders() {
        const data = await getOrders();
        setOrders(data);
    }
    
    
    return (
        <div>
            <h2>Orders List</h2>

            {orders.map(order => (
                <div key={order.orderId}>
                    <hr/>
                    <p>{order.orderNumber}</p>
                    <p>{order.senderCity}</p>
                    <p>{order.senderAddress}</p>
                    <p>{order.receiverCity}</p>
                    <p>{order.receiverAddress}</p>
                    <p>{order.weight}</p>
                    <p>{order.pickUpDate}</p>
                    <hr/>
                </div>
            ))}
            
        </div>
    );
}

export default OrdersPage;