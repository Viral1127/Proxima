import { HeroSection } from "@/components/hero-section"
import { FeatureSection } from "@/components/feature-section"
import { TestimonialSection } from "@/components/testimonial-section"
import { Button } from "@/components/ui/button"
import Link from 'next/link'

export default function Home() {
  return (
    <div className="min-h-screen flex flex-col">
      <header className="bg-white shadow-sm">
        <div className="container mx-auto py-4 flex justify-between items-center">
          <h1 className="text-2xl font-bold text-primary">Proxima</h1>
          <nav>
            <ul className="flex space-x-4">
              <li><a href="#features" className="text-gray-600 hover:text-primary">Features</a></li>
              <li><a href="#testimonials" className="text-gray-600 hover:text-primary">Testimonials</a></li>
              <li>
                <Button asChild variant="outline">
                  <Link href="/login">Log In</Link>
                </Button>
              </li>
            </ul>
          </nav>
        </div>
      </header>

      <main className="flex-grow">
        <HeroSection />
        <div id="features">
          <FeatureSection />
        </div>
        <div id="testimonials">
          <TestimonialSection />
        </div>
      </main>

      <footer className="bg-gray-800 text-white py-8">
        <div className="container mx-auto text-center">
          <p>&copy; 2023 Proxima. All rights reserved.</p>
        </div>
      </footer>
    </div>
  )
}

