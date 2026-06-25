<%@ include file="../common/header.jspf" %>

<section class="page-heading">
    <div>
        <p class="eyebrow">Tabela orders</p>
        <h1>Ordens de venda</h1>
    </div>
    <a class="button primary" href="${ctx}/orders?action=new">+ Nova ordem</a>
</section>

<c:if test="${not empty success}">
    <div class="alert success">${success}</div>
</c:if>
<c:if test="${not empty error}">
    <div class="alert error">${error}</div>
</c:if>

<section class="table-panel">
    <table>
        <thead>
        <tr>
            <th>Numero</th>
            <th>Valor</th>
            <th>Data</th>
            <th>Cliente</th>
            <th>Vendedor</th>
            <th class="actions-column">Acoes</th>
        </tr>
        </thead>
        <tbody>
        <c:forEach var="order" items="${orders}">
            <tr>
                <td>${order.ordNo}</td>
                <td>R$ <fmt:formatNumber value="${order.purchAmt}" minFractionDigits="2" maxFractionDigits="2" /></td>
                <td>${order.ordDate}</td>
                <td>${fn:escapeXml(order.customerName)}</td>
                <td>${fn:escapeXml(order.salesmanName)}</td>
                <td class="row-actions">
                    <a class="icon-button" title="Editar" href="${ctx}/orders?action=edit&id=${order.ordNo}">Editar</a>
                    <form method="post" action="${ctx}/orders">
                        <input type="hidden" name="action" value="delete">
                        <input type="hidden" name="id" value="${order.ordNo}">
                        <button class="icon-button danger" type="submit" title="Excluir">Excluir</button>
                    </form>
                </td>
            </tr>
        </c:forEach>
        <c:if test="${empty orders}">
            <tr>
                <td colspan="6" class="empty-state">Nenhuma ordem cadastrada.</td>
            </tr>
        </c:if>
        </tbody>
    </table>
</section>

<%@ include file="../common/footer.jspf" %>