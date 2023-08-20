<template>
  <header>
    <nav
      class="navbar navbar-expand-sm navbar-toggleable-sm navbar-expand-lg bg-primary border-bottom box-shadow mb-3"
    >
      <div class="container-fluid">
        <router-link class="navbar-brand" to="/">exampleWeb</router-link>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target=".navbar-collapse"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div
          class="navbar-collapse collapse d-sm-inline-flex justify-content-between"
        >
          <ul class="navbar-nav me-auto">
            <li class="nav-item">
              <router-link class="nav-link text-dark" to="/"
                >Home<span class="visually-hidden">(current)</span></router-link
              >
            </li>
            <li class="nav-item">
              <router-link class="nav-link text-dark" to="/category"
                >Category</router-link
              >
            </li>
            <li class="nav-item">
              <router-link class="nav-link text-dark" to="/privacy"
                >Privacy</router-link
              >
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                data-bs-toggle="dropdown"
                href="#"
                role="button"
                aria-haspopup="true"
                aria-expanded="false"
                >Dropdown</a
              >
              <div class="dropdown-menu">
                <a class="dropdown-item" href="#">Action</a>
                <a class="dropdown-item" href="#">Another action</a>
                <a class="dropdown-item" href="#">Something else here</a>
                <div class="dropdown-divider"></div>
                <a class="dropdown-item" href="#">Separated link</a>
              </div>
            </li>
          </ul>
          <form class="d-flex">
            <input
              class="form-control me-sm-2"
              type="search"
              placeholder="Search"
            />
            <button class="btn btn-secondary my-2 my-sm-0" type="submit">
              Search
            </button>
          </form>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: "AppHeader",
};
</script>
