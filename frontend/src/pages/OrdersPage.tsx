import type {Order} from "../types/order.ts";
import {useEffect, useState} from "react";
import {getOrders} from "../api/ordersApi.ts";
import {Link} from "react-router-dom";
import "../styles/OrdersPage.css";

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
        <div className="orders-page">

            <div className="page-header">

                <h1 className="page-title">
                    Orders
                </h1>

                <Link
                    to="/orders/create"
                    className="create-button"
                >
                    + Create Order
                </Link>

            </div>

            <div className="orders-grid">

                {orders.map(order => (

                    <div
                        key={order.orderId}
                        className="order-card"
                    >

                        <div className="order-number">
                            {order.orderNumber}
                        </div>

                        <div className="order-route">
                            📦 {order.senderCity}
                            {" → "}
                            {order.receiverCity}
                        </div>

                        <div className="order-info">
                            Weight: {order.weight} kg
                        </div>

                        <div className="order-info">
                            Pickup:
                            {" "}
                            {new Date(
                                order.pickUpDate
                            ).toLocaleString()}
                        </div>

                        <Link
                            to={`/orders/${order.orderId}`}
                            className="details-link"
                        >
                            View Details →
                        </Link>

                    </div>

                ))}

            </div>

        </div>
    );
}

export default OrdersPage;