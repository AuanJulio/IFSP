<%@ include file="../common/header.jspf" %>

<section class="page-heading">
    <div>
        <p class="eyebrow">Tabela customer</p>
        <h1>${editing ? 'Editar cliente' : 'Novo cliente'}</h1>
    </div>
    <a class="button secondary" href="${ctx}/customers">Voltar</a>
</section>

<c:if test="${not empty error}">
    <div class="alert error">${error}</div>
</c:if>

<section class="form-panel">
    <form method="post" action="${ctx}/customers" class="data-form">
        <input type="hidden" name="editing" value="${editing}">

        <label>
            Codigo
            <input type="number" name="customerId" min="1" max="99999" required value="${customer.customerId == 0 ? '' : customer.customerId}" ${editing ? 'readonly' : ''}>
        </label>

        <label>
            Nome
            <input type="text" name="custName" maxlength="30" required value="${fn:escapeXml(customer.custName)}">
        </label>

        <label>
            Cidade
            <input type="text" name="city" maxlength="15" required value="${fn:escapeXml(customer.city)}">
        </label>

        <label>
            Nota
            <input type="number" name="grade" min="0" max="999" required value="${customer.grade == 0 ? '' : customer.grade}">
        </label>

        <label>
            Vendedor
            <select name="salesmanId" required>
                <option value="">Selecione</option>
                <c:forEach var="salesman" items="${salesmen}">
                    <option value="${salesman.salesmanId}" ${salesman.salesmanId == customer.salesmanId ? 'selected' : ''}>
                        ${salesman.salesmanId} - ${fn:escapeXml(salesman.name)}
                    </option>
                </c:forEach>
            </select>
        </label>

        <div class="form-actions">
            <button class="button primary" type="submit">Salvar</button>
            <a class="button ghost" href="${ctx}/customers">Cancelar</a>
        </div>
    </form>
</section>

<%@ include file="../common/footer.jspf" %>