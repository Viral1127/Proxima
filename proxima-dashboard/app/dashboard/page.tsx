import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { ProjectBoard } from "@/components/project-board"
import { BoardHeader } from "@/components/board-header"

export default function DashboardPage() {
  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto">
          <div className="container mx-auto p-6">
            <BoardHeader />
            <ProjectBoard />
          </div>
        </main>
      </div>
    </div>
  )
}

