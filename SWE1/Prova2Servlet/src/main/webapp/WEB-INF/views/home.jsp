<%@ include file="common/header.jspf" %>

<section class="hero">
    <div>
        <p class="eyebrow">Modelo salesman - customer - orders</p>
        <h1>Controle de vendas</h1>
        <p class="lead">Cadastro de vendedores, clientes e ordens com banco de dados relacional.</p>
    </div>
    <div class="quick-actions">
        <a class="button primary" href="${ctx}/orders?action=new">+ Nova ordem</a>
        <a class="button secondary" href="${ctx}/customers?action=new">+ Novo cliente</a>
        <a class="button secondary" href="${ctx}/salesmen?action=new">+ Novo vendedor</a>
    </div>
</section>

<section class="stats-grid" aria-label="Resumo dos cadastros">
    <article class="stat-card">
        <span>Vendedores</span>
        <strong>${salesmanCount}</strong>
    </article>
    <article class="stat-card">
        <span>Clientes</span>
        <strong>${customerCount}</strong>
    </article>
    <article class="stat-card">
        <span>Ordens</span>
        <strong>${orderCount}</strong>
    </article>
</section>

<section class="overview-grid">
    <a class="module-link" href="${ctx}/salesmen">
        <span class="module-icon">S</span>
        <strong>Vendedores</strong>
        <small>Nome, cidade e comissao.</small>
    </a>
    <a class="module-link" href="${ctx}/customers">
        <span class="module-icon">C</span>
        <strong>Clientes</strong>
        <small>Nota, cidade e vendedor responsavel.</small>
    </a>
    <a class="module-link" href="${ctx}/orders">
        <span class="module-icon">O</span>
        <strong>Ordens de venda</strong>
        <small>Valor, data, cliente e vendedor.</small>
    </a>
</section>

<%@ include file="common/footer.jspf" %>