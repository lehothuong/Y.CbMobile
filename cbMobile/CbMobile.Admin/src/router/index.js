import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

import Layout from "@/layout";

export const constantRoutes = [
  {
    path: "/login",
    component: () => import("@/views/login/index"),
    hidden: true
  },
  {
    path: "/auth-redirect",
    component: () => import("@/views/login/auth-redirect"),
    hidden: true
  },
  {
    path: "/404",
    component: () => import("@/views/error-page/404"),
    hidden: true
  },
  {
    path: "/401",
    component: () => import("@/views/error-page/401"),
    hidden: true
  },
  {
    path: "/",
    component: Layout,
    redirect: "/dashboard",
    children: [
      {
        path: "dashboard",
        component: () => import("@/views/dashboard/index"),
        name: "Trang chủ",
        meta: { title: "Dashboard", icon: "dashboard", affix: true }
      }
    ]
  }
];

export const asyncRoutes = [
  {
    path: "/permission",
    component: Layout,
    redirect: "/permission/page",
    alwaysShow: true, // will always show the root menu
    name: "Permission",
    meta: {
      title: "Permission",
      icon: "lock",
      roles: ["admin", "editor"] // you can set roles in root nav
    },
    children: [
      {
        path: "page",
        component: () => import("@/views/permission/page"),
        name: "PagePermission",
        meta: {
          title: "Page Permission",
          roles: ["admin"] // or you can only set roles in sub nav
        }
      },
      {
        path: "directive",
        component: () => import("@/views/permission/directive"),
        name: "DirectivePermission",
        meta: {
          title: "Directive Permission"
          // if do not set roles, means: this page does not require permission
        }
      },
      {
        path: "role",
        component: () => import("@/views/permission/role"),
        name: "RolePermission",
        meta: {
          title: "Role Permission",
          roles: ["admin"]
        }
      }
    ]
  },
  {
    path: "/order",
    component: Layout,
    children: [
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/order/edit"),
        name: "EditOrder",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/order/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/order/list"),
        name: "ListOrder",
        meta: { title: "Đơn hàng", icon: "shopping" }
      }
    ]
  },
  {
    path: "/category-product",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/category-product/create"),
        name: "CreateCategoryProduct",
        hidden: true,
        meta: { title: "Create", icon: "edit" }
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/category-product/edit"),
        name: "EditCategoryProduct",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/category-product/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/category-product/list"),
        name: "ListCategoryProduct",
        meta: { title: "Loại sản phẩm", icon: "form" }
      }
    ]
  },
  {
    path: "/product",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/product/create"),
        name: "CreateProduct",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/product/edit"),
        name: "EditProduct",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/product/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/product/list"),
        name: "ListProduct",
        meta: { title: "Sản phẩm", icon: "leaf" }
      }
    ]
  },
  {
    path: "/main-memory",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/main-memory/create"),
        name: "CreateMainMemory",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/main-memory/edit"),
        name: "EditMainMemory",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/main-memory/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/main-memory/list"),
        name: "ListMainMemory",
        meta: { title: "Bộ nhớ", icon: "memory" }
      }
    ]
  },
  {
    path: "/main-color",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/main-color/create"),
        name: "CreateMainColor",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/main-color/edit"),
        name: "EditMainColor",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/main-color/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/main-color/list"),
        name: "ListMaincolor",
        meta: { title: "Màu sắc", icon: "eglass-color" }
      }
    ]
  },
  {
    path: "/specification",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/specification/create"),
        name: "CreateSpecification",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/specification/edit"),
        name: "EditSpecification",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/specification/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/specification/list"),
        name: "ListSpecification",
        meta: { title: "Thông số kỹ thuật", icon: "eglass-color" }
      }
    ]
  },
  {
    path: "/accessories",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/accessories/create"),
        name: "CreateAccessories",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/accessories/edit"),
        name: "EditAccessories",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/accessoriesr/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/accessories/list"),
        name: "ListAccessories",
        meta: { title: "Chi tiết sản phẩm", icon: "details" }
      }
    ]
  },

  {
    path: "/manufacturer",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/manufacturer/create"),
        name: "CreateManufacturer",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/manufacturer/edit"),
        name: "EditManufacturer",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/manufacturer/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/manufacturer/list"),
        name: "Bộ nhớ",
        meta: { title: "Nhà sản xuất", icon: "supplier_group" }
      }
    ]
  },

  {
    path: "/category-banner",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/category-banner/create"),
        name: "CreateCategoryBanner",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/category-banner/edit"),
        name: "EditCategoryBanner",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/category-banner/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/category-banner/list"),
        name: "ListCategoryBanner",
        meta: { title: "Loại Banner", icon: "form" }
      }
    ]
  },
  {
    path: "/banner",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/banner/create"),
        name: "CreateBanner",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/banner/edit"),
        name: "EditBanner",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/banner/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/banner/list"),
        name: "ListBanner",
        meta: { title: "Banner", icon: "shuffling-banner" }
      }
    ]
  },

  {
    path: "/category-post",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/category-post/create"),
        name: "CreateCategoryPost",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/category-post/edit"),
        name: "EditCategoryPost",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/category-post/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/category-post/list"),
        name: "ListCategoryPost",
        meta: { title: "Loại tin tức", icon: "clip-type-new" }
      }
    ]
  },
  {
    path: "/news",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/news/create"),
        name: "CreateNews",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/news/edit"),
        name: "EditNews",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/news/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/news/list"),
        name: "ListNews",
        meta: { title: "Tin tức", icon: "News" }
      }
    ]
  },
  {
    path: "/topic",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/topic/create"),
        name: "CreateTopic",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/topic/edit"),
        name: "EditTopic",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/topic/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/topic/list"),
        name: "ListTopic",
        meta: { title: "Bài viết", icon: "Post-a-Job" }
      }
    ]
  },
  {
    path: "/contact",
    component: Layout,
    name: "Liên hệ",
    meta: {
      title: "Liên hệ",
      icon: "example"
    },
    children: [
      {
        path: "contact",
        component: () => import("@/views/contact/list"),
        name: "Contact",
        meta: { title: "Contact", icon: "contact" }
      },
      {
        path: "review",
        component: () => import("@/views/review/list"),
        name: "Review",
        meta: { title: "Review", icon: "review" }
      }
    ]
  },
  {
    path: "/location",
    component: Layout,
    children: [
      {
        path: "create",
        component: () => import("@/views/location/create"),
        name: "CreateLocation",
        meta: { title: "Create", icon: "edit" },
        hidden: true
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/location/edit"),
        name: "EditLocation",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/location/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/location/list"),
        name: "ListLocation",
        meta: { title: "Địa chỉ", icon: "icon-location" }
      }
    ]
  },
  { path: "*", redirect: "/404", hidden: true }
];

const createRouter = () =>
  new Router({
    // mode: 'history', // require service support
    mode: 'history',
    scrollBehavior: () => ({ y: 0 }),
    routes: constantRoutes
  });

const router = createRouter();

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter() {
  const newRouter = createRouter();
  router.matcher = newRouter.matcher; // reset router
}

export default router;
