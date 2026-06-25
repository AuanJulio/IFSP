<%@ include file="../common/header.jspf" %>

<section class="page-heading">
    <div>
        <p class="eyebrow">Tabela salesman</p>
        <h1>Vendedores</h1>
    </div>
    <a class="button primary" href="${ctx}/salesmen?action=new">+ Novo vendedor</a>
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
            <th>Comissao</th>
            <th class="actions-column">Acoes</th>
        </tr>
        </thead>
        <tbody>
        <c:forEach var="salesman" items="${salesmen}">
            <tr>
                <td>${salesman.salesmanId}</td>
                <td>${fn:escapeXml(salesman.name)}</td>
                <td>${fn:escapeXml(salesman.city)}</td>
                <td><fmt:formatNumber value="${salesman.commission}" minFractionDigits="2" maxFractionDigits="2" /></td>
                <td class="row-actions">
                    <a class="icon-button" title="Editar" href="${ctx}/salesmen?action=edit&id=${salesman.salesmanId}">Editar</a>
                    <form method="post" action="${ctx}/salesmen">
                        <input type="hidden" name="action" value="delete">
                        <input type="hidden" name="id" value="${salesman.salesmanId}">
                        <button class="icon-button danger" type="submit" title="Excluir">Excluir</button>
                    </form>
                </td>
            </tr>
        </c:forEach>
        <c:if test="${empty salesmen}">
            <tr>
                <td colspan="5" class="empty-state">Nenhum vendedor cadastrado.</td>
            </tr>
        </c:if>
        </tbody>
    </table>
</section>

<%@ include file="../common/footer.jspf" %>