<%@ include file="../common/header.jspf" %>

<section class="page-heading">
    <div>
        <p class="eyebrow">Tabela salesman</p>
        <h1>${editing ? 'Editar vendedor' : 'Novo vendedor'}</h1>
    </div>
    <a class="button secondary" href="${ctx}/salesmen">Voltar</a>
</section>

<c:if test="${not empty error}">
    <div class="alert error">${error}</div>
</c:if>

<section class="form-panel">
    <form method="post" action="${ctx}/salesmen" class="data-form">
        <input type="hidden" name="editing" value="${editing}">

        <label>
            Codigo
            <input type="number" name="salesmanId" min="1" max="99999" required value="${salesman.salesmanId == 0 ? '' : salesman.salesmanId}" ${editing ? 'readonly' : ''}>
        </label>

        <label>
            Nome
            <input type="text" name="name" maxlength="30" required value="${fn:escapeXml(salesman.name)}">
        </label>

        <label>
            Cidade
            <input type="text" name="city" maxlength="15" required value="${fn:escapeXml(salesman.city)}">
        </label>

        <label>
            Comissao
            <input type="number" name="commission" min="0" step="0.01" required value="${salesman.commission}">
        </label>

        <div class="form-actions">
            <button class="button primary" type="submit">Salvar</button>
            <a class="button ghost" href="${ctx}/salesmen">Cancelar</a>
        </div>
    </form>
</section>

<%@ include file="../common/footer.jspf" %>