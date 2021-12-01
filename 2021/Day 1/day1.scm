(load "input.scm")

; Part 1
(define (solver lst)
  (if (null? (cdr lst))
      0
      (+ (if (< (car lst) (cadr lst)) 1 0)
         (solver (cdr lst)))))

(solver input)


; Part 2
(define (helper lst)
  (if (null? (cddr lst))
      '()
      (cons (+ (car lst) (cadr lst) (caddr lst))
            (helper (cdr lst)))))

(solver (helpr input))




