import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { UserManagement } from "@/components/user-management"

export default function UsersPage() {
  return (
    <div className="flex h-screen bg-gray-100">
      <Sidebar />
      <div className="flex-1 flex flex-col overflow-hidden">
        <Header />
        <main className="flex-1 overflow-x-hidden overflow-y-auto bg-gray-100">
          <div className="container mx-auto px-6 py-8">
            <h1 className="text-3xl font-semibold text-gray-800 mb-6">User Management</h1>
            <UserManagement />
          </div>
        </main>
      </div>
    </div>
  )
}

