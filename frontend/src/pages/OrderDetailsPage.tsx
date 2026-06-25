import { Link, useParams } from "react-router-dom";
import { getOrderById } from "../api/ordersApi.ts";
import { useEffect, useState } from "react";
import type { OrderDetails } from "../types/orderDetails.ts";
import "../styles/OrderDetailsPage.css";

function OrderDetailsPage() {
    const { id } = useParams();
    const [order, setOrder] = useState<OrderDetails | null>(null);

    useEffect(() => {
        if (id) {
            loadOrder(id);
        }
    }, [id]);

    async function loadOrder(orderId: string) {
        const data = await getOrderById(orderId);
        setOrder(data);
    }

    if (!order) {
        return (
            <div className="page-container">
                <div className="details-card">
                    <h2 className="loading-text">Loading...</h2>
                </div>
            </div>
        );
    }

    return (
        <div className="page-container">
            <div className="details-card">
                <h1 className="details-title">Order Details</h1>

                <div className="details-grid">
                    {/* 1. Order Number – полная ширина */}
                    <div className="detail-item full-width">
                        <span className="detail-label">Order Number</span>
                        <span className="detail-value">{order.orderNumber}</span>
                    </div>

                    {/* 2. Sender City – левая колонка */}
                    <div className="detail-item">
                        <span className="detail-label">Sender City</span>
                        <span className="detail-value">{order.senderCity}</span>
                    </div>

                    {/* 3. Sender Address – правая колонка */}
                    <div className="detail-item">
                        <span className="detail-label">Sender Address</span>
                        <span className="detail-value">{order.senderAddress}</span>
                    </div>

                    {/* 4. Receiver City – левая колонка (новая строка) */}
                    <div className="detail-item">
                        <span className="detail-label">Receiver City</span>
                        <span className="detail-value">{order.receiverCity}</span>
                    </div>

                    {/* 5. Receiver Address – правая колонка */}
                    <div className="detail-item">
                        <span className="detail-label">Receiver Address</span>
                        <span className="detail-value">{order.receiverAddress}</span>
                    </div>

                    {/* 6. Weight – полная ширина */}
                    <div className="detail-item full-width">
                        <span className="detail-label">Weight</span>
                        <span className="detail-value">{order.weight} kg</span>
                    </div>

                    {/* 7. Pickup Date – полная ширина */}
                    <div className="detail-item full-width">
                        <span className="detail-label">Pickup Date</span>
                        <span className="detail-value">
                            {new Date(order.pickUpDate).toLocaleString()}
                        </span>
                    </div>

                    {/* 8. Created At – левая колонка */}
                    <div className="detail-item">
                        <span className="detail-label">Created At</span>
                        <span className="detail-value">
                            {new Date(order.createdAt).toLocaleString()}
                        </span>
                    </div>

                    {/* 9. Order ID – правая колонка (с моноширинным шрифтом) */}
                    <div className="detail-item">
                        <span className="detail-label">Order ID</span>
                        <span className="detail-value mono">{order.id}</span>
                    </div>
                </div>

                <Link to="/" className="back-link">
                    ← Back to Orders
                </Link>
            </div>
        </div>
    );
}

export default OrderDetailsPage;