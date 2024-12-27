import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { ProjectBoard } from "@/components/project-board"
import { Button } from "@/components/ui/button"
import { PlusCircle } from 'lucide-react'

export default function ProjectsPage() {
  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-7xl mx-auto">
            <div className="flex justify-between items-center mb-6">
              <h1 className="text-2xl font-semibold text-gray-900">Projects</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                New Project
              </Button>
            </div>
            <ProjectBoard />
          </div>
        </main>
      </div>
    </div>
  )
}

