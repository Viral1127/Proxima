import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { ProjectBoard } from "@/components/project-board"

export default function ProjectsPage() {
  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <ProjectBoard />
      </div>
    </div>
  )
}

