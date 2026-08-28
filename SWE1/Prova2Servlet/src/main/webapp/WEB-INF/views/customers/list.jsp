<%@ include file="../common/header.jspf" %>

<section class="page-heading">
    <div>
        <p class="eyebrow">Tabela customer</p>
        <h1>Clientes</h1>
    </div>
    <a class="button primary" href="${ctx}/customers?action=new">+ Novo cliente</a>
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
            <th>Codigo</th>
            <th>Nome</th>
            <th>Cidade</th>
            <th>Nota</th>
            <th>Vendedor</th>
            <th class="actions-column">Acoes</th>
        </tr>
        </thead>
        <tbody>
        <c:forEach var="customer" items="${customers}">
            <tr>
                <td>${customer.customerId}</td>
                <td>${fn:escapeXml(customer.custName)}</td>
                <td>${fn:escapeXml(customer.city)}</td>
                <td>${customer.grade}</td>
                <td>${fn:escapeXml(customer.salesmanName)}</td>
                <td class="row-actions">
                    <a class="icon-button" title="Editar" href="${ctx}/customers?action=edit&id=${customer.customerId}">Editar</a>
                    <form method="post" action="${ctx}/customers">
                        <input type="hidden" name="action" value="delete">
                        <input type="hidden" name="id" value="${customer.customerId}">
                        <button class="icon-button danger" type="submit" title="Excluir">Excluir</button>
                    </form>
                </td>
            </tr>
        </c:forEach>
        <c:if test="${empty customers}">
            <tr>
                <td colspan="6" class="empty-state">Nenhum cliente cadastrado.</td>
            </tr>
        </c:if>
        </tbody>
    </table>
</section>

<%@ include file="../common/footer.jspf" %>