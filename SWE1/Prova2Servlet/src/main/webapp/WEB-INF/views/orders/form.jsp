<%@ include file="../common/header.jspf" %>

<section class="page-heading">
    <div>
        <p class="eyebrow">Tabela orders</p>
        <h1>${editing ? 'Editar ordem' : 'Nova ordem'}</h1>
    </div>
    <a class="button secondary" href="${ctx}/orders">Voltar</a>
</section>

<c:if test="${not empty error}">
    <div class="alert error">${error}</div>
</c:if>

<section class="form-panel">
    <form method="post" action="${ctx}/orders" class="data-form">
        <input type="hidden" name="editing" value="${editing}">

        <label>
            Numero
            <input type="number" name="ordNo" min="1" max="99999" required value="${order.ordNo == 0 ? '' : order.ordNo}" ${editing ? 'readonly' : ''}>
        </label>

        <label>
            Valor
            <input type="number" name="purchAmt" min="0" step="0.01" required value="${order.purchAmt}">
        </label>

        <label>
            Data
            <input type="date" name="ordDate" required value="${order.ordDate}">
        </label>

        <label>
            Cliente
            <select name="customerId" required>
                <option value="">Selecione</option>
                <c:forEach var="customer" items="${customers}">
                    <option value="${customer.customerId}" ${customer.customerId == order.customerId ? 'selected' : ''}>
                        ${customer.customerId} - ${fn:escapeXml(customer.custName)}
                    </option>
                </c:forEach>
            </select>
        </label>

        <label>
            Vendedor
            <select name="salesmanId" required>
                <option value="">Selecione</option>
                <c:forEach var="salesman" items="${salesmen}">
                    <option value="${salesman.salesmanId}" ${salesman.salesmanId == order.salesmanId ? 'selected' : ''}>
                        ${salesman.salesmanId} - ${fn:escapeXml(salesman.name)}
                    </option>
                </c:forEach>
            </select>
        </label>

        <div class="form-actions">
            <button class="button primary" type="submit">Salvar</button>
            <a class="button ghost" href="${ctx}/orders">Cancelar</a>
        </div>
    </form>
</section>

<%@ include file="../common/footer.jspf" %>